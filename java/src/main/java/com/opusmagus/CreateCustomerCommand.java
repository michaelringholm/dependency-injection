package com.opusmagus;

import org.springframework.stereotype.Component;

@Component
public class CreateCustomerCommand implements ICommand {
	public CreateCustomerCommand() {
		System.out.println("CreateCustomerCommand initialized!");
	}
}