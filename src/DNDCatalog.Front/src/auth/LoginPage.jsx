import React, { useState } from 'react';
import axios from 'axios';
import {useForm} from 'react-hook-form';
import { Form, FormControl, FormGroup, FormLabel, Button, Alert } from 'react-bootstrap';
import { useLocalStorageState } from 'react-localstorage-hooks';

export const LoginPage = () => {

    const {register, handleSubmit } = useForm();

    const [alertMessage, setAlertMessage] = useState("");
    const [alertMessageType, setAlertMessageType] = useState("danger");

    const [authToken, setAuthToken] = useLocalStorageState("authToken");
    const [authUsername, setAuthUsername] = useLocalStorageState("authUsername");
    const [isAuthenticated, setAuth] = useLocalStorageState("isAuthenticated");

    const onSubmit = async (data) =>
    {
        setAlertMessage("");
        console.log(data);
        axios
            .post('api/v1/authenticate', data)
            .then((response)=>
            {
                console.log(response);

                if(response.status !== 200)
                    throw 'Login error'

                if(response.data.result !== true)
                    throw 'Login error'
                
                console.log(response.data.token);
               
                setAuthToken(response.data.token);
                setAuthUsername(data.username);
                setAuth(true);

                setAlertMessageType("success");
                setAlertMessage("Successfully Logged in");
            })
            .catch((error) => 
            {
                console.log(error);
                setAlertMessageType("danger");
                setAlertMessage(error);
            });
    }

    const logout = () =>
    {
        setAuth(false);
        setAuthToken("");
        setAuthUsername("");
    }

    if(!isAuthenticated) return (
      <div>
        <h1>Login</h1>
        {alertMessage!=="" && 
            <Alert variant={alertMessageType} onClose={() => setAlertMessage("")} dismissible>
                {alertMessageType === "danger" && <Alert.Heading>Login Error!</Alert.Heading> }
                <p>{alertMessage}</p>
            </Alert>
        }
        <Form onSubmit={handleSubmit(onSubmit)} >
            <FormGroup className="mb-3" controlId="email">
                <FormLabel>Email address</FormLabel>
                <FormControl type="email" {...register("username")} placeholder="please type your email"/>
            </FormGroup>
            <FormGroup className="mb-3" controlId="password">
                <FormLabel>Email address</FormLabel>
                <FormControl type="password" {...register("password")} placeholder="your password here"/>
            </FormGroup>
            <Button type="submit">Login</Button>
        </Form>
      </div>
    );
    else return (
        <div>
            <h1>Hello, {authUsername}!</h1>
            <Button onClick={logout}>Logout</Button>
        </div>
    );
}
