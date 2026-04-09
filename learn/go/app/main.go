package main

import (
	"fmt"
	route "learn/go/internal"

	"github.com/gin-gonic/gin"
)

func main() {

	r := gin.Default()
	route.MapRoutes(r)

	fmt.Printf("Hello")

	r.GET("/", func(c *gin.Context) {
		c.JSON(200, gin.H{
			"message": "Api working!",
		})
	})
	r.Run(":8080")

}
