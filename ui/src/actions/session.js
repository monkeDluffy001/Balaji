import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

export const login = createAsyncThunk('session/login', async (payload, thunkApi) => {
  try {
    const { data, callback } = payload;
    const res = await axios.post(`Session/login`, data);

    if (res?.ErrorsCount > 0) {
      throw Error('something went wrong');
    } else {
      if (callback) {
        callback();
      }
      return res.data?.data[0];
    }
  } catch (error) {
    return thunkApi.rejectWithValue(error);
  }
});
