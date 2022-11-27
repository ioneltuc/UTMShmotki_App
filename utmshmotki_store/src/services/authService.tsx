import { environment } from "../environments/environment";

type UserInfo = {
    userName: string;
    password: string;
}

export async function login(userInfo: UserInfo) {
    try{
        const response = await fetch(`${environment.apiUrl}login`, {
            method: "POST",
            credentials: "include",
            body: JSON.stringify(userInfo),
            headers: {
                "Content-Type": "application/json",
            },   
        })
        if(!response.ok){
            throw new Error("Something went wrong")
        }

        return await response.json()
    }catch(e){
        return []
    }   
}

export async function getUser() {
    try{
        const response = await fetch(`${environment.apiUrl}user`, {
            headers: {
                "Content-Type": "application/json",
            },
            credentials: "include"
        })
        if(!response.ok){
            throw new Error("Something went wrong")
        }

        return await response.json()
    }catch(e){
        return new Response()
    }   
}

export async function logout() {
    try{
        const response = await fetch(`${environment.apiUrl}logout`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            credentials: "include"
        })
        if(!response.ok){
            throw new Error("Something went wrong")
        }

        return await response.json()
    }catch(e){
        return[]
    }  
}