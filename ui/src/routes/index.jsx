import { createBrowserRouter } from 'react-router-dom';
import BasicLayout from '../layouts/BasicLayout';
// No need load lazy as vite handle that by default
import ErrorPage from '../pages/ErrorPage';
import Login from '../pages/Login';
import SignUp from '../pages/SignUp';
import AuthLayout from '../layouts/AuthLayout';
import Dashboard from '../pages/Dashboard';

const rootRouter = createBrowserRouter([
  {
    path: '/',
    element: <BasicLayout />,
    children: [
      { path: '', element: <Login /> },
      { path: 'register', element: <SignUp /> },
    ],
  },
  {
    path: 'dashboard',
    element: <AuthLayout />,
    children: [{ path: '', element: <Dashboard /> }],
  },
  {
    path: '*',
    element: <ErrorPage />,
  },
]);

export default rootRouter;
