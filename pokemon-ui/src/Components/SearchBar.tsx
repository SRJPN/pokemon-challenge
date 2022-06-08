const SearchBar = ({keyword}: {keyword:string}) => (
    <form action="/" method="get">
        <label htmlFor="header-search">
            <span className="visually-hidden">Search Pokemon</span>
        </label>
        <input
            type="text"
            id="header-search"
            placeholder="Search Pokemon"
            name="pokemon" 
            defaultValue={keyword}
        />
        <button type="submit">Search</button>
    </form>
);

export default SearchBar;