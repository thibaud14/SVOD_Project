class CreatePeople < ActiveRecord::Migration
  def change
    create_table :people do |t|
      t.string :firstname
      t.string :name
      t.date :birthdate

      t.timestamps
    end
  end
end
