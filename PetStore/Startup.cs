﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PetStore.Db;
using PetStore.Models.DomainModels;
using PetStore.Services.Interfaces;
using PetStore.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Threading.Tasks;
using AutoMapper;
using PetStore.Filters;
using FluentValidation.AspNetCore;

namespace PetStore
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.Configure<CookiePolicyOptions>(options =>
			{
				// This lambda determines whether user consent for non-essential cookies is needed for a given request.
				options.CheckConsentNeeded = context => true;
				options.MinimumSameSitePolicy = SameSiteMode.None;
			});


			// Add authentication services
			// Setting up auth0 middleware
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
			})
			.AddCookie()
			.AddOpenIdConnect("Auth0", options =>
			{
				// Set the authority to your Auth0 domain
				options.Authority = $"https://{Configuration["Auth0:Domain"]}";

				// Configure the Auth0 Client ID and Client Secret
				options.ClientId = Configuration["Auth0:ClientId"];
				options.ClientSecret = Configuration["Auth0:ClientSecret"];

				// Set response type to code
				options.ResponseType = "code";

				// Configure the scope
				options.Scope.Clear();
				options.Scope.Add("openid");
				options.Scope.Add("email");
				options.Scope.Add("profile");

				// Set the callback path, so Auth0 will call back to http://localhost:3000/callback
				// Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard
				options.CallbackPath = new PathString("/signin-auth0");

				// Configure the Claims Issuer to be Auth0
				options.ClaimsIssuer = "Auth0";

				options.Events = new OpenIdConnectEvents
				{
					// handle the logout redirection
					OnRedirectToIdentityProviderForSignOut = (context) =>
							{
								var logoutUri = $"https://{Configuration["Auth0:Domain"]}/v2/logout?client_id={Configuration["Auth0:ClientId"]}";

								var postLogoutUri = context.Properties.RedirectUri;
								if (!string.IsNullOrEmpty(postLogoutUri))
								{
									if (postLogoutUri.StartsWith("/"))
									{
										// transform to absolute
										var request = context.Request;
										postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
									}
									logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
								}

								context.Response.Redirect(logoutUri);
								context.HandleResponse();

								return Task.CompletedTask;
							}
				};
			});

			services.AddAutoMapper(typeof(Startup));

			services.AddMvc(opt => opt.Filters.Add(new ExceptionFilter()))
				.SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
								.AddFluentValidation(fv =>
								{
									fv.RegisterValidatorsFromAssemblyContaining<Startup>();
									fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
								});

			services.AddDbContext<PetStoreContext>(opts =>
				opts
				.UseLazyLoadingProxies()
				.UseSqlServer(Configuration["DbConnectionString"]));

			// Initialization of scoped repositories, references to database.
			services.AddScoped<IRepository<Product>, ProductRepository>();
			services.AddScoped<IRepository<Order>, OrderRepository>();
			services.AddScoped<IRepository<User>, UserRepository>();

			// Initialization of custom scoped services.
			services.AddScoped<IManagementService, ManagementService>();
			services.AddScoped<IUserService, UserService>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseCookiePolicy();

			app.UseAuthentication();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
