import { configureStore } from '@reduxjs/toolkit';
import logger from 'redux-logger';
import rootReducer from '../reducers';

export const store = configureStore({
  reducer: rootReducer,
  middleware: (getDefaultMiddleware) =>
    import.meta.env.NODE_ENV !== 'production' ? getDefaultMiddleware().concat(logger) : getDefaultMiddleware(),
  devTools: import.meta.env.NODE_ENV !== 'production',
});
