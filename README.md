# OAuthAuthDemo
API Authentication using OAuth - C# .NET 9

# OAuthAuthDemo

OAuthAuthDemo is a simple application that demonstrates how to implement **OAuth 2.0** authentication using **Google OAuth** in an ASP.NET Core Web API. This example uses cookies to authenticate users after they log in via Google and then authorize them to access protected resources.

## Features

- **Google OAuth Authentication**: Users can log in with their Google accounts to authenticate.
- **Cookie-based Authentication**: Once authenticated, users are redirected to a protected API endpoint.
- **Protected API Endpoint**: The application has a protected `TestController` which requires authentication for access.
- **OAuth Flow**: The app demonstrates the OAuth 2.0 authentication flow with Google.

## Prerequisites

Before running this project, you need to create OAuth credentials from **Google Cloud Console**. Follow these steps:

### Google Cloud Console Setup

1. Go to [Google Cloud Console](https://console.cloud.google.com/).
2. Create a new project or select an existing one.
3. Navigate to **APIs & Services > Credentials**.
4. Under **OAuth 2.0 Client IDs**, click **Create Credentials**.
5. Set the **Authorized redirect URIs** to `https://localhost:7277/signin-google`.
6. Note down your **Client ID** and **Client Secret**.

### Local Development Environment

To run this application locally, you'll need:

- **.NET 6 or later** installed on your machine.
- A Google account to authenticate via OAuth.
- **Visual Studio Code** or any other IDE to edit and run the code.
- Google OAuth credentials as explained above.

## Setting Up the Project

1. Clone the repository:

   ```bash
   git clone https://github.com/prateekprabhakar1992/OAuthAuthDemo.git
   cd OAuthAuthDemo


2. Create a appsettings.json file in the root directory with your Google OAuth credentials:

{
  "Google": {
    "ClientId": "YOUR_GOOGLE_CLIENT_ID",
    "ClientSecret": "YOUR_GOOGLE_CLIENT_SECRET"
  }
}


3. Install necessary dependencies via NuGet (you can skip this step if you're using Visual Studio):

    ```bash
    dotnet restore
    Run the application:
    dotnet run
    The application will start at https://localhost:7277.

## Endpoints
1. /api/Test/data (GET)
This is the main API endpoint. When you attempt to access this endpoint, you will be redirected to Google's OAuth service to authenticate if you are not already authenticated. After successful authentication, the data will be returned.

2. /api/Test/login-google (GET)
This endpoint is not required in this implementation. The authentication process is automatically triggered when accessing the /api/Test/data endpoint.

## Authentication Flow

1. The user navigates to /api/Test/data in the browser.
2. If the user is not authenticated, they will be redirected to Google's OAuth authentication page.
3. After the user grants permission, they are redirected back to the app.
4. The app saves the user's session in a cookie and grants access to the protected API (/api/Test/data).
5. The authenticated user is able to access protected endpoints.

# How OAuth Authentication Works in This App

Google OAuth is used for authentication.
When a user visits the /api/Test/data endpoint, they are redirected to the Google OAuth login page.
Once the user signs in successfully, the app creates an authentication cookie to store the user’s session.
After signing in, the user is redirected back to the API endpoint, where the protected data is returned if the user is authenticated.
Expiration and Refresh Tokens
This demo does not implement token refreshing, so the authentication session expires when the user closes the browser or after the cookie expires (based on the cookie configuration). For a production-level app, you would typically implement Refresh Tokens to keep users logged in without requiring them to authenticate repeatedly.

# Conclusion

This simple demonstration introduces the core concepts of OAuth authentication using Google in an ASP.NET Core application. You can expand upon this by implementing more complex OAuth workflows, like handling multiple OAuth providers or implementing role-based access control.