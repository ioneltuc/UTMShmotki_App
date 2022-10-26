import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { deleteProductById, getProductById } from "../services/productService";
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import { Button } from "@mui/material";

type Product = {
    id: number,
    name: string,
    description: string,
    price: number
}

function ProductDetails(){

    const[item, setItem] = useState<Product>()
    const { id } = useParams();

    useEffect(() => {
        fetchData();
    }, [])

    const fetchData = async () => {
        const data = await getProductById(id);
        setItem(data)
    }

    const deleteProduct = async () => {
        await deleteProductById(id)
        setTimeout(() => {
            window.location.reload()
        },500)
    }

    return(
        <div>
            <h3>{item?.name}</h3>
            <h4>{item?.description}</h4>
            <h4>{item?.price}</h4>
            <Button variant="outlined" startIcon={<EditIcon fontSize="large"/>} id="update-product-btn">
                <Link to={`/update/${id}`} className="product-btn-text">
                    Update product
                </Link>
            </Button>
            <Button variant="outlined" startIcon={<DeleteIcon fontSize="large" />} id="delete-product-btn">
                <Link to="/" onClick={deleteProduct} className="product-btn-text">
                    Delete product
                </Link>
            </Button>
        </div>
    )
}

export default ProductDetails