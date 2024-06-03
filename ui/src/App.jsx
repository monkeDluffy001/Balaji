import './App.css';
import { CssBaseline } from '@mui/material';
import ThemeProvider from './theme';
import { Suspense } from 'react';
import rootRouter from './routes/index';
import { RouterProvider } from 'react-router-dom';
import { configureAxios } from './constants/axios';

configureAxios();
function App() {
  return (
    <ThemeProvider>
      <CssBaseline />
      <Suspense fallback={<div>Loading...</div>}>
        <RouterProvider router={rootRouter} />
      </Suspense>
    </ThemeProvider>
  );
}

export default App;
