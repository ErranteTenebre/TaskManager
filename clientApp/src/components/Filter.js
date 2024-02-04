import React, {useState} from 'react';

const Filter = ({setFilteredTasks, tasks, setStatus, setDataSort}) => {
    const [isFilterListVisible, setFilterListVisible] = useState(true);

    const toggleFilterListVisibility = () => {
        setFilterListVisible(!isFilterListVisible);
        };
        const filterListStyle = {
            display: isFilterListVisible ? "flex" : "none",
        };

        const handleFilterChange = (event) =>{
            setStatus(event.target.value);
        }

        const handleSortChange = (event) =>{
            setDataSort(event.target.value);
        }

        return (
            <div className="filter-panel">
                <a className="link  filter-panel__button" onClick={toggleFilterListVisibility}>
                    <div className="fa fa-filter"></div>
                </a>

                <ul className="filter-panel__list" style={filterListStyle}>
                    <li className="filter-panel__item">
                        <select className="select" defaultValue="Любой статус" onChange={handleFilterChange}>
                            <option value="any">Любой статус</option>
                            <option value="completed">Выполнена</option>
                            <option value="inprocess">В процессе</option>
                            <option value="waiting">Ожидание</option>
                        </select>
                    </li>

                    <li className="filter-panel__item">
                        <select className="select" defaultValue="Сортировка по дате окончания" onChange={handleSortChange}>
                            <option value="descending">По убыванию</option>
                            <option value="ascending">По возрастанию</option>
                        </select>
                    </li>
                </ul>
            </div>
       
        )
}

export default Filter;