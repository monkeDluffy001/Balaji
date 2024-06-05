import { createBrowserRouter } from 'react-router-dom';
import BasicLayout from '../layouts/BasicLayout';
// No need load lazy as vite handle that by default
import ErrorPage from '../pages/ErrorPage';
import Login from '../pages/Login';
import SignUp from '../pages/SignUp';
import AuthLayout from '../layouts/AuthLayout';
import Dashboard from '../pages/Dashboard';
import UsersPage from '../pages/Users';
import Products from '../pages/Products';
import ContractConfiguration from '../pages/ContractConfiguration';

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
    path: 'users',
    element: <AuthLayout />,
    children: [{ path: '', element: <UsersPage /> }],
  },
  {
    path: 'products',
    element: <AuthLayout />,
    children: [{ path: '', element: <Products /> }],
  },
  {
    path: 'contract',
    element: <AuthLayout />,
    children: [{ path: '', element: <ContractConfiguration /> }],
  },
  {
    path: '*',
    element: <ErrorPage />,
  },
]);

export default rootRouter;
