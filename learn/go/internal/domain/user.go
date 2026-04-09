package domain

type User struct {
	ID   int    `json:"id"`
	Name string `json:"name"`
	Age  int    `json:"age"`
}

type UserRepository interface {
	GetUserByID(id int) (*User, error)
}

type UserService interface {
	GetUserByID(id int) (*User, error)
}
