package com.opusmagus;

import org.apache.commons.logging.Log;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class Console implements CommandLineRunner {
    public static void main(String[] args) {
        System.out.println("Dependency injection demo");
        SpringApplication.run(Console.class, args);        
    }

    @Autowired private Log logger;
    @Autowired private CreateCustomerCommand createCustomerCommand;
	@Override
	public void run(String... args) throws Exception {
		logger.info("Running...");
		createCustomerCommand.Execute();
	}
}