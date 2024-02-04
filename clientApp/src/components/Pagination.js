import React from 'react';

const Pagination = ({ currentPage, totalPages, onPageChange }) => {
    const renderPageNumbers = () => {
        const pages = [];
        const adjacentPages = 2;

        if (totalPages === 0) return null;

        pages.push(
            <li key={1} className={currentPage === 1 ? 'pagination__link--active' : ''}>
                <a href="#" onClick={() => onPageChange(1)}>1</a>
            </li>
        );

        if (currentPage - adjacentPages > 2) {
            pages.push(
                <li key="ellipsis1">
                    <span>...</span>
                </li>
            );
        }

        for (let i = currentPage - adjacentPages; i <= currentPage + adjacentPages; i++) {
            if (i > 1 && i < totalPages) {
                pages.push(
                    <li key={i} className={currentPage === i ? 'pagination__link--active' : ''}>
                        <a href="#" onClick={() => onPageChange(i)}>{i}</a>
                    </li>
                );
            }
        }

        if (currentPage + adjacentPages < totalPages - 1) {
            pages.push(
                <li key="ellipsis2">
                    <span>...</span>
                </li>
            );
        }

        if (totalPages != 1)
            pages.push(
                <li key={totalPages} className={currentPage === totalPages ? 'pagination__link--active' : ''}>
                    <a href="#" onClick={() => onPageChange(totalPages)}>{totalPages}</a>
                </li>
            );

        return pages;
    };

    return (
        <ul className="pagination">
            {renderPageNumbers()}
        </ul>
    );
};

export default Pagination;