import React from 'react';
import { useGlobalState } from './state';

export const LoginLink = () => {

    const [isAuthenticated] = useGlobalState("isAuthenticated");
    const [email] = useGlobalState("email");

    return (
      <span>{isAuthenticated?email:"Login"}</span>
    );
}
