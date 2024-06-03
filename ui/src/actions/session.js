import { createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

export const login = createAsyncThunk('session/login', async (data, thunkApi) => {
  try {
    const res = await axios.post('/api/Session/login', data);

    if (res?.ErrorsCount > 0) {
      throw Error('something went wrong');
    } else {
      return res.data;
    }
  } catch (error) {
    return thunkApi.rejectWithValue(error);
  }
});
