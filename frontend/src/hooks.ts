import { useDispatch, useSelector } from "react-redux";
import type { RootState, AppDispatch } from "./app/store";

// Typed versions of hooks
export const useAppDispatch: () => AppDispatch = useDispatch;
export const useAppSelector = useSelector.withTypes<RootState>();
