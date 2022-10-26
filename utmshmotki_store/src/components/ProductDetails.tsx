import { useEffect, useState } from "react";
import { Link, useParams } from "react-router-dom";
import { deleteProductById, getProductById } from "../services/productService";
import DeleteIcon from '@mui/icons-material/Delete';
import EditIcon from '@mui/icons-material/Edit';

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
            <button>
                <Link to={`/update/${id}`}>
                    <EditIcon fontSize="large"/>
                </Link>
            </button>
            <Link to="/" onClick={deleteProduct}>
                <DeleteIcon fontSize="large" />
            </Link>
        </div>
    )
}

export default ProductDetails