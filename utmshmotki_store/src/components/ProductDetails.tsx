import { useEffect, useState } from "react";
import { Link, useNavigate, useParams } from "react-router-dom";
import { deleteProductById, getProductById, getProductImage } from "../services/productService";
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';
import { Button } from "@mui/material";
import placeholder from '../assets/images/product_placeholder.png'
import { getUser } from "../services/authService";

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
    const [user, setUser] = useState('')

    useEffect(() => {
        (
            async () => {
                const response = await getUser()
                setUser(response.userName)
            }
        )()
    }, [user])
    
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
            <img id="single-product-image" src={imageSrc} width="300px" />
            <p className="single-product-description">{item?.description}</p>
            <h3 className="single-product-price">{item?.price} MDL</h3>
            { 
                user
                &&
                <>
                    <Button variant="outlined" startIcon={<EditIcon fontSize="large"/>} id="update-product-btn">
                        <Link to={`/update/${id}`} className="product-btn-text">
                            Update product
                        </Link>
                    </Button>
                    <Button id="delete-product-btn" variant="outlined" startIcon={<DeleteIcon fontSize="large" />} onClick={() => deleteProduct()}>
                        Delete product
                    </Button>
                </>
            }
        </div>
    )
}

export default ProductDetails