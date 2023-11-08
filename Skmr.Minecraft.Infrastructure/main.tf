terraform{
    required_providers {
      aws = {
        source = "hashicorp/aws"
        version = "~> 5.0"
      }
    }
}

provider "aws" {
    region = "eu-central-1"
}

resource "aws_iam_role" "iam_lambda_minecraft" {
  name               = "iam_for_lambda"
  assume_role_policy = data.aws_iam_policy_document.assume_role.json
}

resource "aws_instance" "server"{
      instance_type = "t2.micro"
}

resource "aws_lambda_function" "start"{
    filename = ""
    function_name = "minecraft.start"

    environment {
        variables = {
            INSTANCE_ID = "bar"
        }
    }
}

resource "aws_lambda_function" "stop"{
    filename = ""
    function_name = "minecraft.stop"

    environment {
        variables = {
            INSTANCE_ID = "bar"
        }
    }
}