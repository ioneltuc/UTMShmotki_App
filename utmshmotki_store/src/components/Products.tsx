import { Box, Button, FormControl, InputLabel, MenuItem, Pagination, Select, SelectChangeEvent, Stack, TextField } from "@mui/material"
import { useEffect, useState } from "react"
import { Link } from "react-router-dom"
import { getProducts } from "../services/productService"
import AddIcon from '@mui/icons-material/Add';

type Product = {
    id: number,
    name: string,
    description: string,
    price: number
}

function Products(){

const[item, setItem] = useState<Product[]>([])
const[pageNumber, setPageNumber] = useState(1)
const[pageSize, setPageSize] = useState(5)
const[pageCount, setPageCount] = useState(5)
const[searchString, setSearchString] = useState('')
const[sortType, setSortType] = useState('')

useEffect(() => {
    fetchData();
}, [])

useEffect(() => {
    fetchData();
}, [pageNumber, pageSize, searchString, sortType])

const fetchData = async () => {
    const data = await getProducts(pageNumber, pageSize, searchString, sortType);
    setItem(data)
}

const handleChangePageNumber = (e: any, page: number) => {
    setPageNumber(page)
}

const handleChangePageSize = (e: any) => {
    setPageSize(e.target.value)
}

const handleChangeSearchString = (e: any) => {
    setSearchString(e.target.value)
}

const handleChangeSortType = (e: SelectChangeEvent) => {
    setSortType(e.target.value)
}

    return(
        <div className="main-page">
            <Button variant="outlined" startIcon={<AddIcon/>} id="add-product-btn">
                <Link to="/add" className="product-btn-text">
                    <span>Add a product</span>
                </Link>
            </Button>
            <div className="filtering-form">
                <TextField label="Search ..." value={searchString} onChange={handleChangeSearchString} />
                <FormControl sx={{ minWidth: 120 }}>
                    <InputLabel>Sort by ...</InputLabel>
                    <Select 
                        value={sortType}
                        label="Sort by ..."
                        onChange={handleChangeSortType}
                    >
                        <MenuItem value="">None</MenuItem>
                        <MenuItem value="name">Sort by name ascending</MenuItem>
                        <MenuItem value="namedesc">Sort by name descending</MenuItem>
                        <MenuItem value="price">Sort by price ascending</MenuItem>
                        <MenuItem value="pricedesc">Sort by price descending</MenuItem>
                    </Select>
                </FormControl>
                <FormControl sx={{ minWidth: 120 }}>
                    <InputLabel>Page size</InputLabel>
                    <Select 
                        value={pageSize}
                        label="Page size"
                        onChange={handleChangePageSize}
                    >
                        <MenuItem value={5}>5</MenuItem>
                        <MenuItem value={10}>10</MenuItem>
                        <MenuItem value={15}>15</MenuItem>
                        <MenuItem value={20}>20</MenuItem>
                    </Select>
                </FormControl>
            </div>
            <Box className="products-container">
                <Stack spacing={3}>
                    {item.map(p => {
                        return(
                            <Link key={p.id} to={{pathname:`/${p.id}`}} className="single-product">
                                <h2>{p.name}</h2>
                                <p><strong>Description: </strong>{p.description}</p>
                                <p><strong>Price: </strong>${p.price}</p>
                            </Link> 
                        )
                    })}
                </Stack>
            </Box>
            <Pagination count={pageCount} page={pageNumber} onChange={handleChangePageNumber}/>
        </div>
    )
}

export default Products