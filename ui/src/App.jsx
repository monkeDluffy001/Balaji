import { CssBaseline } from '@mui/material';
import ThemeProvider from './theme';
import { Suspense } from 'react';
import rootRouter from './routes/index';
import { RouterProvider } from 'react-router-dom';
import { configureAxios } from './constants/axios';
import 'react-toastify/dist/ReactToastify.css';
import { ToastContainer } from 'react-toastify';

configureAxios();
function App() {
  return (
    <ThemeProvider>
      <CssBaseline />
      <Suspense fallback={<div>Loading...</div>}>
        <RouterProvider router={rootRouter} />
      </Suspense>
      <ToastContainer />
    </ThemeProvider>
  );
}

export default App;
