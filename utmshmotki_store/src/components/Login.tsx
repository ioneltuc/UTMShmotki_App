import { yupResolver } from "@hookform/resolvers/yup";
import { useForm } from "react-hook-form";
import * as yup from "yup"
import { Button } from "@mui/material";
import { login } from "../services/authService";
import { useNavigate } from "react-router-dom";

type FormTypes = {
    userName: string;
    password: string;
}

const schema = yup.object({
    userName: yup.string().required("Username is required"),
    password: yup.string().required("Password is required").min(8, "Password is too short"),
})

function Login(){
    
    const navigate = useNavigate();
    const {register, handleSubmit, formState:{errors}} = useForm<FormTypes>({
        resolver: yupResolver(schema)
    })

    const onSubmit = async (values: FormTypes) => {
        await login(values)
        navigate('/', {replace: true})
    }

    return(
        <form onSubmit={handleSubmit(onSubmit)}>
            <h1>Please sign in</h1>

            <label htmlFor="username">Username</label>
            <input id="username" type="text" {...register("userName")}></input>
            {errors.userName && <span className="form-error">{errors.userName.message}</span>}

            <label htmlFor="password">Password</label>
            <input id="password" type="password"{...register("password")}></input>
            {errors.password && <span className="form-error">{errors.password.message}</span>}

            <Button type="submit">Sign In</Button>
        </form>
    )
}

export default Login