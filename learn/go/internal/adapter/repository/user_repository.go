package repository

import (
	"learn/go/internal/domain"

	"gorm.io/gorm"
)

type GormUserRepository struct {
	db *gorm.DB
}

func NewGormUserRepository(db *gorm.DB) *GormUserRepository {
	return &GormUserRepository{db: db}
}

func (r *GormUserRepository) GetUserByID(id int) (*domain.User, error) {
	var user domain.User

	// GORM sẽ tự tìm trong bảng 'users' (dựa trên tên struct User)
	if err := r.db.First(&user, id).Error; err != nil {
		return nil, err
	}

	return &user, nil
}
