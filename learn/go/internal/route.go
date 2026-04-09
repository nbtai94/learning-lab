package route

import (
	"github.com/gin-gonic/gin"
)

func MapRoutes(r *gin.Engine) {
	// 4. Định nghĩa Group API v1
	v1 := r.Group("/api/")
	{
		userGroup := v1.Group("/users")
		{
			// GET /api/v1/users/:id
			userGroup.GET("/:id")
		}
	}
}
