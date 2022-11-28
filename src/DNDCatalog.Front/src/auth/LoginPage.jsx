import React, { useState } from 'react';
import axios from 'axios';
import {useForm} from 'react-hook-form';
import { Form, FormControl, FormGroup, FormLabel, Button, Alert } from 'react-bootstrap';
import { setGlobalState, useGlobalState } from './state';

export const LoginPage = () => {

    const {register, handleSubmit } = useForm();
    const [isAuthenticated] = useGlobalState("isAuthenticated");
    const [email] = useGlobalState("email");
    const [alertMessage, setAlertMessage] = useState("");
    const [alertMessageType, setAlertMessageType] = useState("danger");

//    const setState = (key, val) =>
//    {
//        setGlobalState(key, val);
//        localStorage.setItem(key, JSON.stringify(val));
//    }


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
                setGlobalState("token", response.data.token);
                setGlobalState("email", data.username);
                setGlobalState("authData", response.data);
                setGlobalState("isAuthenticated", true);
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
        setGlobalState("isAuthenticated", false);
        setGlobalState("token", "");
        setGlobalState("email", "");
        setGlobalState("authData", {});
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
            <h1>Hello, {email}!</h1>
            <Button onClick={logout}>Logout</Button>
        </div>
    );
}
