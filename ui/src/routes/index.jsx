import { createBrowserRouter } from 'react-router-dom';
import BasicLayout from '../layouts/BasicLayout';
// No need load lazy as vite handle that by default
import ErrorPage from '../pages/ErrorPage';
import Login from '../pages/Login';
import SignUp from '../pages/SignUp';

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
    path: '*',
    element: <ErrorPage />,
  },
]);

export default rootRouter;
