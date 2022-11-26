import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { deleteProductById, getProductById, getProductImage } from "../services/productService";
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import { Button } from "@mui/material";
import placeholder from '../assets/images/product_placeholder.png'

type Product = {
    id: number,
    name: string,
    description: string,
    price: number
}

function ProductDetails(){

    const[item, setItem] = useState<Product>()
    const[imageSrc, setImageSrc] = useState('');
    const { id } = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        fetchData();
    }, [])

    const fetchData = async () => {
        const data = await getProductById(id);
        const productImage = await getProductImage(id)
        setItem(data)
        setImageSrc(URL.createObjectURL(productImage))
    }

    const deleteProduct = async () => {
        const toDelete:boolean = window.confirm("Delete product with id " + id + "?")
        if(toDelete) {
            await deleteProductById(id)
            navigate('/', {replace: true})
        }
    }

    return(
        <div className="product-details">
            <h1>{item?.name}</h1>
            <img id="product-image" src={imageSrc} width="500px"/>
            <h3 className="single-product-description">{item?.description}</h3>
            <h3 className="single-product-price">{item?.price} MDL</h3>
            <Button variant="outlined" startIcon={<EditIcon fontSize="large"/>} id="update-product-btn">
                <Link to={`/update/${id}`} className="product-btn-text">
                    Update product
                </Link>
            </Button>
            <Button id="delete-product-btn" variant="outlined" startIcon={<DeleteIcon fontSize="large" />} onClick={() => deleteProduct()}>
                Delete product
            </Button>
        </div>
    )
}

export default ProductDetails