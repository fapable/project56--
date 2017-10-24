import * as React from 'react'; 
import { RouteComponentProps } from 'react-router';
import * as Models from './Models';

async function LoadProducts() : Promise<Models.Product[]>
{
    let query = await fetch('./products/GetAll', { method: 'get', credentials: 'include', headers: {'content-type': 'application/json'}})
    console.log("Fetch", query)
    let result = await query.json()
    return result.map((e:any) => {return{Title:e.title}}) //We gebruiken dit omdat de json alles lowercase maakt maar bij de models de variabele namen met uppercase zijn. Daarom fixen wij alles hier met de map.
}

export class Products extends React.Component<RouteComponentProps<{}>, {products : Models.Product[] | "loading"}>
{
    constructor(props:RouteComponentProps<{}>)
    {     
        super(props)
        this.state = {products:"loading"}
    }
    componentWillMount()
    {
        LoadProducts().then(p => {
            console.log(p)
            this.setState({... this.state, products : p})})
    }

    render()
    {
        console.log("rerendered", this.state.products)
        if (this.state.products == "loading") return <div>Loading...</div>
        return <div className="products">
            <h1>Hello Products</h1>
            { this.state.products.map(p => <div className="product_title">
                <div>
                    {p.Title}
                
                </div>
            </div>)}
        </div>
    }
}