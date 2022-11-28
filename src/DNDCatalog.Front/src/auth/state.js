import { createGlobalState } from "react-hooks-global-state";

const {setGlobalState, useGlobalState} = createGlobalState(
    {
        token: "",
        isAuthenticated: false,
        email: "",
        authData: {},
    });

export {setGlobalState, useGlobalState};