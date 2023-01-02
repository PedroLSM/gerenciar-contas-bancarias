import { useReducer, useCallback } from "react";

interface HttpReducerAction {
  type: string;
  responseData?: any;
  errorMessage?: string;
}

function httpReducer(state: any, action: HttpReducerAction) {
  if (action.type === "SEND") {
    return {
      data: null,
      error: null,
      status: "pending",
    };
  }

  if (action.type === "SUCCESS") {
    return {
      data: action.responseData,
      error: null,
      status: "completed",
    };
  }

  if (action.type === "ERROR") {
    return {
      data: null,
      error: action.errorMessage,
      status: "completed",
    };
  }

  return state;
}

function useHttp(requestFunction: Function, startWithPending = false) {
  const [httpState, dispatch] = useReducer(httpReducer, {
    status: startWithPending ? "pending" : null,
    data: null,
    error: null,
  });

  const sendRequest = useCallback(
    async (requestData: any) => {
      dispatch({ type: "SEND" });
      try {
        const responseData = await requestFunction(requestData);

        dispatch({ type: "SUCCESS", responseData });

        return responseData;
      } catch (error: any) {
        dispatch({
          type: "ERROR",
          errorMessage: error.message || "⚠️ Ops! Algo deu errado.",
        });
      }
    },
    [requestFunction]
  );

  return {
    sendRequest,
    ...httpState,
  } as {
    sendRequest: any;
    status: "pending" | "completed" | null;
    data: any;
    error: any;
  };
}

export default useHttp;
