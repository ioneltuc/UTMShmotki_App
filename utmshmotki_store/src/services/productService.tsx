type Product = {
    name: string;
    description: string;
    price: number
}

export async function getProducts(pageNumber: number, pageSize: number, searchString: string, sortType: string){
    try{
        const response = await fetch(`https://localhost:7061/api/product/?pagenumber=${pageNumber}&pagesize=${pageSize}` +
            `${searchString === '' ? '' : '&search=' + searchString}${sortType === '' ? '' : '&sort=' + sortType}`);
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
        const response = await fetch("https://localhost:7061/api/product/" + id);
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
        const response = await fetch("https://localhost:7061/api/product", {
            method: "POST",
            body: JSON.stringify(product),
            headers: {
                "accept": "text/plain",
                "Content-Type": "application/json",
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
        const response = await fetch("https://localhost:7061/api/product/" + id, {
            method: "PUT",
            body: JSON.stringify(product),
            headers: {
                "accept": "*/*",
                "Content-Type": "application/json",
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
        const response = await fetch("https://localhost:7061/api/product/" + id, {
            method: "DELETE",
            headers: {
                "accept": "*/*",
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