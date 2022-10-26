import { Box, Button, FormControl, Grid, InputLabel, MenuItem, Pagination, Select, SelectChangeEvent, TextField } from "@mui/material"
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
const[pageCount, setPageCount] = useState(10)
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
        <div>
            <Button>
                <Link to="/add">
                    <div>
                        <AddIcon/>
                        Add a product
                    </div>
                </Link>
            </Button>
            <div>
                <TextField label="Search" value={searchString} onChange={handleChangeSearchString} />
                <FormControl sx={{ minWidth: 120 }}>
                    <InputLabel>Sort by</InputLabel>
                    <Select 
                        value={sortType}
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
                        onChange={handleChangePageSize}
                    >
                        <MenuItem value={5}>5</MenuItem>
                        <MenuItem value={10}>10</MenuItem>
                        <MenuItem value={15}>15</MenuItem>
                        <MenuItem value={20}>20</MenuItem>
                    </Select>
                </FormControl>
            </div>
            <Box sx={{width: '100%'}}>
                <Grid container rowSpacing={3} columnSpacing={3}>
                    {item.map(p => {
                        return(
                            <Grid key={p.id} item xs={4}>
                                <Link to={{pathname:`/${p.id}`}}>
                                    <p><strong>{p.name}</strong></p>
                                    <p><strong>Description: </strong>{p.description}</p>
                                    <p><strong>Price: </strong>${p.price}</p>
                                </Link>
                            </Grid> 
                        )
                    })}
                </Grid>
            </Box>
            <Pagination count={pageCount} page={pageNumber} onChange={handleChangePageNumber}/>
        </div>
    )
}

export default Products