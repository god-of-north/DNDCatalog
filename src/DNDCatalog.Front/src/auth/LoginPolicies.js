import jwt from 'jwt-decode'

export const logout = () =>
{
    localStorage.setItem("isAuthenticated", JSON.stringify(false));
    localStorage.setItem("authToken", JSON.stringify(""));
    localStorage.setItem("authUsername", JSON.stringify(""));
}

const getStorageItem = (name) =>
{
    const value = localStorage.getItem("authToken");

    if(value == "undefined")
        return null;
    
    return JSON.parse(value);
}

const isExpired = () =>
{
    const authToken = getStorageItem("authToken");
    if(authToken=="")
    {
        logout();
        return true;
    }
    
    const token = jwt(authToken);

    if(Date.now() >= token.exp*1000)
        return true;

    return false;
}

export const applyLoginPolicy = () =>
{
    const isAuthenticated = getStorageItem("isAuthenticated");

    if(isAuthenticated)
    {
        if(isExpired())
            logout();
    }
}


const hasRole = (role) =>
{
    const authToken = getStorageItem("authToken");
    const isAuthenticated = getStorageItem("isAuthenticated");

    if(!isAuthenticated)
        return false;

    const token = jwt(authToken);
    return token.role.includes(role);
}

export const isEditor = () => hasRole("EDITORS");
export const isAdmin = () => hasRole("ADMINISTRATORS");
