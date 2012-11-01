class People < ActiveRecord::Base
  attr_accessible :birthdate, :firstname, :name, :role
  has_and_belongs_to_many :video

 end
