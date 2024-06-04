import { createSlice } from '@reduxjs/toolkit';
import { login } from '../actions/session';
import { RemoveItemFromLocalStorage, SetItemToLocalStorage } from '../utils/localStorage';
import { TOKEN, USER_ID } from '../constants/constants';
import { toast } from 'react-toastify';
import { LOGIN_FAILURE, LOGIN_SUCCESS } from '../constants/Notifications';
import axios from 'axios';

const initialState = {
  loading: false,
  userData: {},
  errors: {},
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
        const data = action.payload;

        SetItemToLocalStorage(TOKEN, data.token);
        SetItemToLocalStorage(USER_ID, data.userId);

        state.userData = action.payload;

        axios.defaults.headers.common = {
          Authorization: `Bearer ${data.token}`,
        };

        toast.success(LOGIN_SUCCESS);
      })
      .addCase(login.rejected, (state, action) => {
        state.loading = false;
        state.errors = action.payload;
        state.data = {};

        RemoveItemFromLocalStorage(TOKEN);
        RemoveItemFromLocalStorage(USER_ID);

        toast.error(LOGIN_FAILURE);
      });
  },
});

export default session.reducer;
