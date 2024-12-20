To run this application in your own environment using Visual Studio, follow these steps:

    Clone/Download the Project
        Create a new directory for your project
        Copy all the files maintaining the same structure

    Set Up the Backend (Mock API)

cd mock-api
npm install express cors jsonwebtoken bcryptjs
npm run dev

    Set Up the Frontend

# In the root directory
npm install
npm run dev

    Environment Requirements

    Node.js (v16 or higher)
    npm (comes with Node.js)
    A modern web browser

    Important Configuration

    Backend runs on http://localhost:5000
    Frontend runs on http://localhost:5173
    Default login credentials:
        Email: john@example.com
        Password: password123

    Development Tools

    Visual Studio Code (recommended)
    Extensions:
        ESLint
        Prettier
        TypeScript and JavaScript Language Features

    Debugging

    Use Chrome DevTools for frontend
    Use VS Code's debugger for backend
    Check console for any errors

The application should now be running locally on your machine.
The frontend will be accessible at http://localhost:5173
and the API will be at http://localhost:5000.
