Rest end point
1. Health check endpoint without authentication that return code 200 OK when service is loaded
   http://localhost:5066/health

3. [RandomUserAPI] : User endpoint that returns random user from https://randomuser.me service.
   User endpoint should have basic authentication with login-password that are set through properties.
   http://localhost:5066/api/User
   with header parameter
   -H 'username: testuser' 
   -H 'password: testpassword'

5. [AngularWebPage] : web page that uses this REST service to show random user.
6. [RandomUserAPI.Test] covered with some test cased
