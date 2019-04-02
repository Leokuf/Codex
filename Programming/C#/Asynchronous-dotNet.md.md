# Asynchronous Programming in .NET

Traditional:
- Threading (low-level)
- Background worker (event-based asynchronous pattern)

Current:
- Task parallel library
- Async and await

## Async and Await

~~~
private async void Search_Click(object sender, RoutedEventArgs e)
{
    // before loading stock data

    using (var client = new HttpClient())
    {
            
        var response = await client.GetAsync($"http://localhost/api/endpoint");

        try
        {
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(content);

            Stocks.ItemsSource = data;      
        }
        catch (Exception ex)
        {
            Notes.Text +=  ex.Message;
        }     
    }

    // after loading stock data
}
~~~

### 

Asynchonous resources are suited for many types of I/O operations
- Disk
- Memory
- Web/API
- Database

### The Await Keyword
- Gives you a potential result
- Validates the success of an operation
- Continuation is back on calling thread
- Marking a method as async indroduces the capability of using the await keyword to leverage the asynchronous principles
- Using async and await in ASP.NET means the web server can handle other requests

~~~

public async void Search_Click(objet sender, RoutedEventArgs e){
    // before loading stock data

    try
    {
        await GetStocks();
    }
    catch (Exception ex)
    {
        Notes.Text += ex.Message;
    }

    // after stock data is loaded
}

// avoid async void at all costs. Only use async void is for event handlers. Exceptions that occur in an async void method cannot be caught
public async Task GetStocks()
{
       var response = await client.GetAsync($"http://localhost/api/endpoint");

        try
        {
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<IEnumerable<StockPrice>>(content);

            Stocks.ItemsSource = data;      
        }
        catch (Exception ex)
        {
            Notes.Text +=  ex.Message;
        }     

}
~~~

## Best practices

### Do not
- Avoid using async void unless it's an event handler or delegate
- Never block an asynchronous operation by calling Result or Wait()

### Do
- Always use async and await together
- Always return a task from an asynchronous method
- Always await an asynchronous method to validate the operation
- Use async and await all the way up the chain


