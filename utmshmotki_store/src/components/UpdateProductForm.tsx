import { useForm } from "react-hook-form"
import * as yup from "yup"
import { yupResolver } from "@hookform/resolvers/yup"
import { getProductById, postProductImage, updateProductById } from "../services/productService";
import { useNavigate, useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import { Button } from "@mui/material";
import EditIcon from '@mui/icons-material/Edit';

type FormTypes = {
    name: string;
    description: string;
    price: number
}

const schema = yup.object({
    name: yup.string().required("Product name is required").max(50, "Name is too long"),
    description: yup.string().max(255, "Description is too long"),
    price: yup.number().transform(value => (isNaN(value) ? 0 : value)).required("Product price is required").min(0, "Price can't be negative")
})

function UpdateProductForm(){

    const[item, setItem] = useState<FormTypes>()
    const navigate = useNavigate();
    const { id } = useParams();
    
    useEffect(() => {
        fetchData();
    }, [])

    const fetchData = async () => {
        const data = await getProductById(id);
        setItem(data)
    }

    useEffect(() => {
        if(item)
        {
            setValue("name", item?.name)
            setValue("description", item?.description)
            setValue("price", item?.price)
        }
    }, [item])

    const {register, setValue, handleSubmit, formState:{errors}} = useForm<FormTypes>({
        resolver: yupResolver(schema),
    })

    const onSubmit = async (values: FormTypes) => {
        await updateProductById(id, values);
        const fileInput = document.querySelector('#productImage') as HTMLInputElement
        let formData = new FormData()
        if(fileInput.files != null) {
            formData.append("formFile", fileInput.files[0])
            await postProductImage(id, formData)
        }
        navigate({pathname:`/${id}`}, {replace: true})
    }

    return(
        <form onSubmit={handleSubmit(onSubmit)}  className="product-form">

            <div>
                <label htmlFor="productName">Product name</label>
                <input id="productName" type="text" {...register("name")}/>
                {errors.name && <span className="form-error">{errors.name.message}</span>}
            </div>

            <div>
                <label htmlFor="productDescription">Product description</label>
                <textarea id="productDescription" {...register("description")}></textarea>
                {errors.description && <span className="form-error">{errors.description.message}</span>}
            </div>

            <div>
                <label htmlFor="productPrice">Product price</label>
                <input id="productPrice" type="number" step="0.01" {...register("price")}/>    
                {errors.price && <span className="form-error">{errors.price.message}</span>}
            </div>

            <div>
                <label htmlFor="productImage" >Product image</label>
                <input id="productImage" type="file" accept="image/png" />
            </div>
            
            <Button type="submit" variant="outlined" startIcon={<EditIcon/>} id="submit-update-product-btn">
                <span className="product-btn-text">Update</span>
            </Button>
        </form>
    )
}

export default UpdateProductForm