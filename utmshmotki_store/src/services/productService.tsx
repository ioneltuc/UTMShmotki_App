import { environment } from "../environments/environment";

type Product = {
    name: string;
    description: string;
    price: number;
}

export async function getProducts(pageNumber: number, pageSize: number, searchString: string, sortType: string){
    try{
        const response = await fetch(`${environment.apiUrl}product/?pagenumber=${pageNumber}&pagesize=${pageSize}` +
            `${searchString === '' ? '' : '&search=' + searchString}${sortType === '' ? '' : '&sort=' + sortType}`, {
        });

        if(!response.ok){
            throw new Error("Something went wrong")
        }

        return await response.json();
    }catch(e){
        return [];
    }
}

export async function getProductById(id: string | undefined){
    try{
        const response = await fetch(`${environment.apiUrl}product/` + id);
        if(!response.ok){
            throw new Error("Something went wrong")
        }

        return await response.json();
    }catch(e){
        return [];
    }
}

export async function postProduct(product: Product){
    try{
        const response = await fetch(`${environment.apiUrl}product`, {
            method: "POST",
            body: JSON.stringify(product),
            headers: {
                "accept": "text/plain",
                "Content-Type": "application/json",
                "Authorization" : "Bearer " + 
                `${getCookie("jwt")}`
            },
        });
        if(!response.ok){
            throw new Error("Something went wrong")
        }

        return await response.json();
    }catch(e){
        return [];
    }
}

export async function updateProductById(id: string | undefined, product: Product){
    try{
        const response = await fetch(`${environment.apiUrl}product/` + id, {
            method: "PUT",
            body: JSON.stringify(product),
            headers: {
                "accept": "*/*",
                "Content-Type": "application/json",
                "Authorization" : "Bearer " + 
                `${getCookie("jwt")}`
            },
        });
        if(!response.ok){
            throw new Error("Something went wrong")
        }

        return await response.json();
    }catch(e){
        return [];
    }
}

export async function deleteProductById(id: string | undefined){
    try{
        const response = await fetch(`${environment.apiUrl}product/` + id, {
            method: "DELETE",
            headers: {
                "accept": "*/*",
                "Authorization" : "Bearer " + 
                `${getCookie("jwt")}`
            },
        });
        if(!response.ok){
            throw new Error("Something went wrong")
        }

        return await response.json();
    }catch(e){
        return [];
    }
}

export async function getProductImage(productId: string | undefined) {
    try{
        const response = await fetch(`${environment.apiUrl}product/image/${productId}`)
        if(!response.ok){
            throw new Error("Something went wrong")
        }

        return await response.blob()

    }catch(e){
        return new Blob()
    }  
}

export async function postProductImage(productId: string | undefined, formData: FormData) {
    try{
        const response = await fetch(`${environment.apiUrl}product/UploadImage?productId=${productId}`, {
            method: "POST",
            headers: {
                "accept" : "text/plain",
                "Authorization" : "Bearer " + 
                `${getCookie("jwt")}`
            },
            body: formData
        })
        if(!response.ok){
            throw new Error("Something went wrong")
        }

        return await response.json()
    }catch(e){
        return [];
    }  
}

function getCookie(name: string) {
    const cookieArr = document.cookie.split(";");
    
    for(let i = 0; i < cookieArr.length; i++) {
        let cookiePair = cookieArr[i].split("=");
        
        if(name == cookiePair[0].trim()) {
            return decodeURIComponent(cookiePair[1]);
        }
    }
    
    return null;
}