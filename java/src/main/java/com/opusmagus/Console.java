package com.opusmagus;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class Console {
    public static void main(String[] args) {
        System.out.println("Dependency injection demo");
        SpringApplication.run(Console.class, args);
    }

}