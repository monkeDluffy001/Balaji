import { createSlice } from '@reduxjs/toolkit';
import { login } from '../actions/session';

const initialState = {
  loading: false,
  count: 0,
  error: {},
};

export const session = createSlice({
  name: 'session',
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(login.pending, (state) => {
        state.loading = true;
      })
      .addCase(login.fulfilled, (state, action) => {
        state.loading = false;
        state.count = action.payload;
      })
      .addCase(login.rejected, (state, action) => {
        state.loading = false;
        console.log('action :', action.payload);
      });
  },
});

export default session.reducer;
