import React from "react";
import {BrowserRouter, Route, Routes} from 'react-router-dom';
import LayoutComponent from "./components/Layout/Layout";
import AboutPage from "./pages/About/About";
import HomePage from "./pages/home/home";
import TestPage from "./pages/Test/test";

export interface IApplicationProps{}

const Application: React.FunctionComponent<IApplicationProps>= (props ) =>{
  return <BrowserRouter>
  <Routes>
    <Route path="/" element={<HomePage/>} />
    <Route path="about" element={<LayoutComponent/>}>
      <Route index element={<AboutPage/>}/>
      <Route path=":number" element={<AboutPage/>}/>
    </Route>
    <Route path="test" element={<TestPage/>}/>
  </Routes>
  </BrowserRouter>;
}
export default Application;