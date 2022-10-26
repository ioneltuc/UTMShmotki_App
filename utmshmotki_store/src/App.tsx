import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css';
import About from './components/About';
import AddProduct from './components/AddProduct';
import Header from './components/Header';
import ProductDetails from './components/ProductDetails';
import Products from './components/Products';
import UpdateProductForm from './components/UpdateProductForm';

function App() {
  return (
    <div className="App">
      <BrowserRouter>
        <Routes>            
          <Route path='/' element={<Header/>}>
            <Route index element={<Products/>}/>
            <Route path="about" element={<About/>}/>
            <Route path="/:id" element={<ProductDetails />} />
            <Route path="/add" element={<AddProduct />} />
            <Route path="/update/:id" element={<UpdateProductForm />} />
          </Route>
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
