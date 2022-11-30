import React from 'react';
import { useLocalStorageState } from 'react-localstorage-hooks';

export const LoginLink = () => {

    const [authUsername] = useLocalStorageState("authUsername");
    const [isAuthenticated] = useLocalStorageState("isAuthenticated");

    return (
      <span>{isAuthenticated?<strong>{authUsername}</strong>:"Увійти"}</span>
    );
}
