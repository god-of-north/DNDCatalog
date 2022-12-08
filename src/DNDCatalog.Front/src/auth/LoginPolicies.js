import jwt from 'jwt-decode'

export const logout = () =>
{
    console.log("----logout");
    localStorage.setItem("isAuthenticated", JSON.stringify(false));
    localStorage.setItem("authToken", JSON.stringify(""));
    localStorage.setItem("authUsername", JSON.stringify(""));
}

const isExpired = () =>
{
    const authToken = JSON.parse(localStorage.getItem("authToken"));
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
    const isAuthenticated = JSON.parse(localStorage.getItem("isAuthenticated"));

    if(isAuthenticated)
    {
        if(isExpired())
            logout();
    }
}


const hasRole = (role) =>
{
    const authToken = JSON.parse(localStorage.getItem("authToken"));
    const isAuthenticated = JSON.parse(localStorage.getItem("isAuthenticated"));

    if(!isAuthenticated)
        return false;

    const token = jwt(authToken);
    return token.role.includes(role);
}

export const isEditor = () => hasRole("EDITORS");
export const isAdmin = () => hasRole("ADMINISTRATORS");
