type UserInfo = {
    userName: string;
    password: string;
}

export async function login(userInfo: UserInfo) {
    try{
        const response = await fetch("https://localhost:7061/api/login", {
            method: "POST",
            credentials: "include",
            body: JSON.stringify(userInfo),
            headers: {
                "accept": "*/*",
                "Content-Type": "application/json",
            },   
        })
        if(!response.ok){
            throw new Error("Something went wrong")
        }

        return await response.json()
    }catch(e){
        return[]
    }   
}

export async function getUser() {
    try{
        const response = await fetch("https://localhost:7061/api/user", {
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