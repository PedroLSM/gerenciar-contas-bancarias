import { useReducer, useCallback } from "react";

interface HttpReducerAction {
  type: string;
  responseData?: any;
  errorMessage?: string;
}

interface DadoErro {
  [key: string]: string[];
}

interface HttpErrorResponse {
  status: number;
  mensagem: string;
  unknownException?: any;
  dados: DadoErro;
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

function handlerError(error: HttpErrorResponse | undefined) {
  if (error) {
    console.log(error);
    if (error.dados) {
      let errorMsg = "";
      for (const key in error.dados) {
        const dado = error.dados[key];

        const erros = dado.map((dd) => `• ${dd}`).join("\n");

        errorMsg += erros;
      }

      return errorMsg || "Ops! Algo deu errado.";
    } else {
      return error.mensagem || "Ops! Algo deu errado.";
    }
  } else {
    return "Ops! Algo deu errado.";
  }
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
        console.log(error);
        dispatch({
          type: "ERROR",
          errorMessage: handlerError(error?.response?.data),
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
