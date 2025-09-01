import { BrowserRouter as Router, Routes, Route, Navigate } from "react-router-dom";
import { useAppSelector } from "./hooks";
import Login from "./features/auth/Login";
import Register from "./features/auth/Register";

function PrivateRoute({ children }: { children: JSX.Element }) {
  const { token } = useAppSelector((state) => state.auth);
  return token ? children : <Navigate to="/login" replace />;
}

function Dashboard() {
  return (
    <div className="p-8">
      <h1 className="text-2xl font-bold">Welcome to Payroll Dashboard 🎉</h1>
      <p className="mt-4">This is a protected route. Only logged-in users can see this.</p>
    </div>
  );
}

export default function App() {
  return (
    <Router>
      <Routes>
        {/* Auth routes */}
        <Route path="/login" element={<Login />} />
        <Route path="/register" element={<Register />} />

        {/* Protected route */}
        <Route
          path="/dashboard"
          element={
            <PrivateRoute>
              <Dashboard />
            </PrivateRoute>
          }
        />

        {/* Default redirect */}
        <Route path="*" element={<Navigate to="/login" replace />} />
      </Routes>
    </Router>
  );
}
