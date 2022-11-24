import { useForm } from "react-hook-form"
import * as yup from "yup"
import { yupResolver } from "@hookform/resolvers/yup"
import { postProduct } from "../services/productService";
import { Button } from "@mui/material";
import AddIcon from '@mui/icons-material/Add';
import { useNavigate } from "react-router-dom";

type FormTypes = {
    name: string;
    description: string;
    price: number;
    imageName: string;
}

const schema = yup.object({
    name: yup.string().required("Product name is required").max(50, "Name is too long"),
    description: yup.string().max(255, "Description is too long"),
    price: yup.number().transform(value => (isNaN(value) ? 0 : value)).required("Product price is required").min(0, "Price can't be negative")
})

function AddProductForm(){
    
    const navigate = useNavigate();
    const {register, handleSubmit, formState:{errors}} = useForm<FormTypes>({
        resolver: yupResolver(schema)
    })

    const onSubmit = async (values: FormTypes) => {
        await postProduct(values);
        navigate('/', {replace: true})
    }

    return(
        <form onSubmit={handleSubmit(onSubmit)} className="product-form">
            <div>
                <label htmlFor="productName">Product name</label>
                <input id="productName" type="text" {...register("name")}/>
                {errors.name && <span className="form-error">{errors.name.message}</span>}
            </div>

            <div>
                <label htmlFor="productDescription">Product description</label>
                <input id="productDescription" type="text" {...register("description")}/>    
                {errors.description && <span className="form-error">{errors.description.message}</span>}
            </div>

            <div>
                <label htmlFor="productPrice">Product price</label>
                <input id="productPrice" type="number" step="0.01" {...register("price")}/>    
                {errors.price && <span className="form-error">{errors.price.message}</span>}
            </div>

            <Button type="submit" variant="outlined" startIcon={<AddIcon/>} id="submit-add-product-btn">
                <span className="product-btn-text">Add</span>
            </Button>
        </form>
    )
}

export default AddProductForm