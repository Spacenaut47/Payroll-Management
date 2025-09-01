import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

interface AuthState {
  token: string | null;
  username: string | null;
  fullName: string | null;
  role: string | null;
  loading: boolean;
  error: string | null;
}

const initialState: AuthState = {
  token: null,
  username: null,
  fullName: null,
  role: null,
  loading: false,
  error: null,
};

// 🌐 API base URL (adjust if backend runs on different port)
const API_URL = "http://localhost:5283/api/auth";

// 🔹 Login thunk
export const login = createAsyncThunk(
  "auth/login",
  async (credentials: { username: string; password: string }, { rejectWithValue }) => {
    try {
      const response = await axios.post(`${API_URL}/login`, credentials);
      return response.data.data; // matches ApiResponse<LoginResponseDto>
    } catch (err: any) {
      return rejectWithValue(err.response?.data?.error || "Login failed");
    }
  }
);

// 🔹 Register thunk
export const register = createAsyncThunk(
  "auth/register",
  async (data: { username: string; password: string; fullName: string; email: string }, { rejectWithValue }) => {
    try {
      const response = await axios.post(`${API_URL}/register`, data);
      return response.data.data; // should be "User created"
    } catch (err: any) {
      return rejectWithValue(err.response?.data?.error || "Registration failed");
    }
  }
);

const authSlice = createSlice({
  name: "auth",
  initialState,
  reducers: {
    logout: (state) => {
      state.token = null;
      state.username = null;
      state.fullName = null;
      state.role = null;
      localStorage.removeItem("token");
    },
    setCredentials: (state, action) => {
      const { token, username, fullName, role } = action.payload;
      state.token = token;
      state.username = username;
      state.fullName = fullName;
      state.role = role;
      localStorage.setItem("token", token);
    },
  },
  extraReducers: (builder) => {
    builder
      // Login
      .addCase(login.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(login.fulfilled, (state, action) => {
        state.loading = false;
        state.error = null;
        state.token = action.payload.token;
        state.username = action.payload.username;
        state.fullName = action.payload.fullName;
        state.role = action.payload.role;
        localStorage.setItem("token", action.payload.token);
      })
      .addCase(login.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload as string;
      })
      // Register
      .addCase(register.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(register.fulfilled, (state) => {
        state.loading = false;
        state.error = null;
      })
      .addCase(register.rejected, (state, action) => {
        state.loading = false;
        state.error = action.payload as string;
      });
  },
});

export const { logout, setCredentials } = authSlice.actions;
export default authSlice.reducer;
